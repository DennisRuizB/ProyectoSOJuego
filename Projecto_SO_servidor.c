#include <stdio.h>
#include <mysql.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <pthread.h>
const int BIND = 9075;
MYSQL *connMYSQL(MYSQL *conn)
{
	int err;
	// acceptem connexió d'un client
	//Conector para acceder al servidor de bases de datos
	//Creamos una conexion al servidor MYSQL
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion, indicando nuestras claves de acceso
	// al servidor de bases de datos (user,pass)
	conn = mysql_real_connect (conn, "localhost","root", "mysql", NULL, 0, NULL, 0);
	if (conn==NULL)
	{
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
}
void Registrar(char p[512], char respuesta[512],MYSQL *conn){
	int err = mysql_query(conn,"use BET365");
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	//1:
	p = strtok(NULL,"/");
	char nombre[200];
	strcpy(nombre,p);
	
	//2:
	p = strtok(NULL,"/");
	int Edad;
	Edad = atoi(p);
	
	//3:
	p = strtok(NULL,"/");
	char contrasena[20];
	strcpy(contrasena,p);
	
	char anadir[500];
	sprintf(anadir,"INSERT INTO Jugadores(Nombre,Edad,Victorias) VALUES ('%s',%d,0);", nombre,Edad);
	err = mysql_query(conn,anadir);
	sprintf(anadir,"INSERT INTO Contrasenas(Contrasena) VALUES ('%s');", contrasena);
	err = mysql_query(conn,anadir);
	if (err!=0) 
		strcpy(respuesta, "No");
	else
		strcpy(respuesta, "Si");
}
void Contrasena(char p[512], char respuesta[512], MYSQL *conn)
{
	int err = mysql_query(conn,"use BET365");
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	p = strtok(NULL,"/");
	char nombre[200];
	strcpy(nombre,p);
	
	
	char consulta[200];
	sprintf(consulta,"SELECT Contrasena FROM (Contrasenas,Jugadores) WHERE Jugadores.Id = Contrasenas.ID AND Jugadores.Nombre = '%s';", nombre);
	err = mysql_query(conn,consulta);
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	strcpy(respuesta,row[0]);
}

void ContrasenaCheck(char p[512], char respuesta[512], MYSQL *conn)
{
	int err = mysql_query(conn,"use BET365");
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	p = strtok(NULL,"/");
	char nombre[200];
	strcpy(nombre,p);
	
	p = strtok(NULL,"/");
	char contrasenaUsu[200];
	strcpy(contrasenaUsu,p);
	
	
	char consulta[200];
	sprintf(consulta,"SELECT Contrasena FROM (Contrasenas,Jugadores) WHERE Jugadores.Id = Contrasenas.ID AND Jugadores.Nombre = '%s';", nombre);
	err = mysql_query(conn,consulta);
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(strcmp(contrasenaUsu, row[0]) == 0)
		sprintf(respuesta,"Si es el usuario");
	else
		sprintf(respuesta,"No es el usuario");
	
}
void FechasGanadas(char p[512], char respuesta[512], MYSQL *conn)
{
	int err = mysql_query(conn,"use BET365");
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	p = strtok(NULL,"/");
	char nombre[200];
	strcpy(nombre,p);
	
	
	
	err = mysql_query(conn,"SELECT * FROM Partidas");
	
	resultado =mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	while(row != NULL)
	{
		if(strcmp(row[1], nombre) == 0)
		{
			sprintf(respuesta,"%s%s/",respuesta,row[2]);
		}
		row = mysql_fetch_row(resultado);
	}
}
void Edad(char p[512], char respuesta[512],MYSQL *conn)
{
	int err = mysql_query(conn,"use BET365");
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	p = strtok(NULL,"/");
	char nombre[200];
	strcpy(nombre,p);
	
	
	err = mysql_query(conn,"SELECT * FROM Jugadores");
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);  
	while(row!=NULL)
	{
		if(strcmp( row[1], nombre) == 0)
		{
			strcpy(respuesta, row[2]);
		}
		row = mysql_fetch_row(resultado);
	}
}
void *AtenderCliente (void*socket)
{
	//iniciamos la connexion SQL
	MYSQL *conn = connMYSQL(conn);;

	char peticion[512];
	char respuesta[512];
	int ret;
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn = *s;
	
	for(int terminar = 0; terminar == 0;)
	{
		memset(respuesta, 0, 512);
		//Servei
		//leemos la peticion 
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf("recibida una peticion\n");
		peticion[ret]= '\0';
		
		//Dividimeos el texto para saber el codigo
		//1:
		char *p = strtok(peticion, "/");
		int codigo = atoi(p);
		
		printf("\n Codigo: %d\n",codigo);
		
		if (codigo == 0)
			terminar = 1;
		//devuelve la edad
		if(codigo == 1)
		{
			Edad(p,respuesta, conn);
		}
		//devuele los años ganados
		else if (codigo == 2)
		{
			FechasGanadas(p,respuesta, conn);
		}
		//devuelve la contraseña
		else if (codigo == 3)
		{
			Contrasena(p,respuesta,conn);
		}
		else if (codigo == 4)
		{
			Registrar(p,respuesta,conn);
		}
		else if (codigo == 5)
		{
			ContrasenaCheck(p,respuesta,conn);
		}
		if(codigo != 0)
		{
			//envia la peticion de vuelta
			printf("la respuesta es %s\n",respuesta);
			write(sock_conn,respuesta,strlen(respuesta));
		}
	}
	close(sock_conn); /* Necessari per a que el client detecti EOF */
}
int main(int argc, char *argv[]) {
	//iniciamos el sock del srvidor
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	//CONECTAMOS MYSQL	
	
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY); /* El fica IP local */
	serv_adr.sin_port = htons(BIND);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
	{
		printf("Error al bind");
		exit(1);
	}
	// Limitem el nombre de connexions pendents
	if (listen(sock_listen, 3) < 0)
		printf("listen");
	int sockets[100];
	pthread_t thread[100];
	for(int i = 0; ;i++)
	{
		printf("escuchando\n");
		//esperamos ha escuchar a un cliente
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Conexion recibida\n");
		sockets[i] = sock_conn;
		pthread_create(&thread[i],NULL,AtenderCliente,&sockets[i]);
		
	}
	return 0;
}

