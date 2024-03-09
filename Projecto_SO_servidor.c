#include <stdio.h>
#include <mysql.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
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
int main(int argc, char *argv[]) {
	//iniciamos la connexion SQL
	MYSQL *conn;
	conn = connMYSQL(conn);
	//iniciamos el sock del srvidor
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;

	char peticion[512];
	char respuesta[512];
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY); /* El fica IP local */
	serv_adr.sin_port = htons(9007);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
	{
		printf("Error al bind");
		exit(1);
	}
	// Limitem el nombre de connexions pendents
	if (listen(sock_listen, 3) < 0)
		printf("listen");
	
	for(;;){
		printf("escuchando\n");
		//esperamos ha escuchar a un cliente
		sock_conn = accept(sock_listen, NULL, NULL);
		//Servei
		//leemos la peticion 
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf("recibida una peticion\n");
		peticion[ret]= '\0';
		write(1, "Missatge rebut\n",16);
		write(1,peticion,strlen(peticion));
		
		//Dividimeos el texto en dos
		//1:
		char *p = strtok(peticion, "/");
		int codigo = atoi(p);
		//2:
		p = strtok(NULL,"/");
		char nombre[200];
		strcpy(nombre,p);
		
		printf("\n Codigo: %d, Nombre: %s\n",codigo,nombre);
		
		//nos metemos en la BASEDATOS
		int err = mysql_query(conn,"use BET365");
		MYSQL_RES *resultado;
		MYSQL_ROW row;
		//devuelve la edad
		if(codigo == 1)
		{
			err = mysql_query(conn,"SELECT * FROM Jugadores");
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);  
			while(row!=NULL)
			{
				if(strcmp( row[0], nombre) == 0)
				{
					strcpy(respuesta, row[0]);
				}
				row = mysql_fetch_row(resultado);
			}
		}
		//devuele los años ganados
		else if (codigo == 2)
		{
			err = mysql_query(conn,"SELECT * FROM Partidas");

			resultado =mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
			while(row != NULL)
			{
				if(strcmp(row[1], nombre))
				{
					sprintf(respuesta,"%s%s/",respuesta,row[2]);
				}
				row = mysql_fetch_row(resultado);
			}
		}
		//devuelve la contraseña
		else if (codigo == 3)
		{
			char consulta[80];
			int err=mysql_query(conn,"use BET365;");
			sprintf(consulta,"SELECT contrasena FROM Contrasenas WHERE Id = %d;", nombre);
			err = mysql_query(conn,consulta);
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
			strcpy(respuesta,row[0]);
		}
		//envia la peticion de vuelta
		printf("la respuesta es %s\n",respuesta);
		write(sock_conn,respuesta,strlen(respuesta));
		close(sock_conn); /* Necessari per a que el client detecti EOF */
	}
	return 0;
}

