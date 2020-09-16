using System;
using System.Data.SqlClient;

namespace SqlInjectDemo
{
    class Program
    {
        public static string ConnectonString = "CONEXAO_DB";
        public static string Nome;
        public static int Operação;
        static void Main()
        {
            UI();
        }

        private static void UI()
        {
            Console.WriteLine("\n\n Exemplo de como realizar ataque de SqlInject\n\n\n");
            Console.WriteLine(" ======================================================");
            Console.WriteLine("\b\b\b \n Escolha uma das operaões para continuar \n ");
            Console.WriteLine("\b 1: \b Realizar consulta com dados Parametrizados ");
            Console.WriteLine("\b 2: \b Realizar consulta com dados Não Parametrizados ");
            Console.WriteLine("\b 3: \b Recriar tabela e inserir dados. ");
            Console.WriteLine("\b 0: \b Sair da Aplicação ");
            Console.WriteLine(" ====================================================== \n");

            Operação = int.Parse(Console.ReadLine());
            RegraDeNegocio();
        }

        public static void RegraDeNegocio()
        {
            switch (Operação)
            {
                case 1:
                    {
                        ConsultaComDadosParametrizados();
                        UI();
                        break;
                    }
                case 2:
                    {
                        ConsultaSemParametrizarOsDados();
                        UI();
                        break;
                    }
                case 3:
                    {
                        CriarTabelaNoDbEInserirDadosParaTeste();
                        UI();
                        break;
                    }
                case 0:
                    {
                        Environment.Exit(1);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n Comando Inválido, tente novamente \n\n");
                        UI();
                        break;
                    }
            }
        }

        private static void ConsultaSemParametrizarOsDados()
        {
            PegarParametro();
            SqlConnection sqlConnection = null;
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlConnection = new SqlConnection(ConnectonString);
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM pessoa WHERE Nome = '" + Nome + "'", sqlConnection);

                sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Console.WriteLine("\n\b\b Id: \b{0},\n Nome: \b {1}", sqlDataReader["Id"], sqlDataReader["Nome"]);
                }
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        private static void ConsultaComDadosParametrizados()
        {
            PegarParametro();
            SqlConnection sqlConnection = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection = new SqlConnection(ConnectonString);
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM pessoa WHERE Nome = @Nome", sqlConnection);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Nome";
                param.Value = Nome;

                cmd.Parameters.Add(param);

                sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Console.WriteLine("\n\b\b Id: \b{0},\n Nome: \b {1}", sqlDataReader["Id"], sqlDataReader["Nome"]);
                }
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        private static void PegarParametro()
        {
            Console.WriteLine("\nInforme o Nome para consulta: \n");
            Nome = Console.ReadLine();
        }

        private static void CriarTabelaNoDbEInserirDadosParaTeste()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectonString); ;
            sqlConnection.Open();
            SqlCommand createTable = new SqlCommand("use[sqlInjectDemo];  create table pessoa(Id int, Nome varchar(50)); insert into pessoa values(1,'Vanderlan');  insert into pessoa values(2,'Marcos');  insert into pessoa values(3,'Isaque');", sqlConnection);
            createTable.ExecuteReader();
            UI();
        }
    }
}

//;'DROP TABLE pessoa--'
//'OR '1'='1'--;'