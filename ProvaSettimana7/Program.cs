using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProvaSettimana7
{
    class Program
    {
        static void Main(string[] args)
        {
            //  1.Cosa ci si aspetta dal seguente codice?
            //try
            // {
            ////codice che può scatenare o non scatenare un’eccezione
            //}
            // finally
            // {
            //  //altro codice
            // }
            //RISPOSTA


            //C) Indipendentemente dal verificarsi o meno di un'eccezione, le istruzioni nella clausola
            //finally verranno eseguite.


            //  2.Dopo aver osservato il seguente codice, selezionare le affermazioni vere.
            //try
            // {
            // }
            // catch (Exception e)
            // {

            // }
            // catch (ArithmeticException a)
            // {

            //  }
            //RISPOSTA

            // B) Il primo blocco catch verrà raggiunto per primo e intercetterà eccezioni di diversa
            // natura, tra cui un’eventuale ArithmeticException
            // C) Qualora venga scatenata un’eccezione ArithmeticException, il secondo blocco catch non
            // sarà mai raggiunto.


            // 3.Quale affermazione, riguardante il codice seguente, è vera ?
            //using System;
            //namespace Test7
            //    {
            // class Program
            // {
            // static void Main(string[] args)
            // {
            //int index = 6;
            //int[] myArray = new int[8];
            //try
            //{
            //    myArray[index] = 10;
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("Fuori dal range");
            //}
            //Console.WriteLine("Fine del programma");
            //  }
            //  }
            // }
            //RISPOSTA

            //D) L’output sarà: Fine del programma.


            //ESERCIZIO 1
            const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = Banca;" +
                                          "Integrated Security=true;";
            ConnessioneDatabase(connectionString);


            //ESERCIZIO 2
            try
            {
                List<string> utenti = new List<string>(); // suppondo di avere ubna lista di utenti
                utenti.Add("Marco");
                utenti.Add("Paolo");
                utenti.Add("Francesco");
                string utenteDaTrovare = "Mario";
                foreach (var item in utenti) //scorro la lista e guardo se uno dei valori della lista è uguale a quello deciso da me
                {
                    if (item == utenteDaTrovare)
                    {
                        Console.WriteLine("utente trovato");
                        break;
                    }
                    else
                    {
                        throw new CustomException("Utente non trovato");//se non trova l'utente allora scatena l'eccezione
                        //l'eccezione verrà scatenata poichè ho inserito un valore non presente nella mia lista

                    }
                }
            }catch(CustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception)
            {

            }

        }

        private static void ConnessioneDatabase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //con il blocco try provo a connettermi al database ,non ci riuscirò perche non possiedo un database Banca,
                //non ho connesso nessun database
                //e inoltre non ho scritto adeguatamente una query quindi sto scatendnao un eccezione
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;


                    command.CommandText = "query";


                    command.ExecuteNonQuery();

                    connection.Close();
                }
                //l'eccezione viene gestita segnalando a video il problema
                catch (SqlException ex)
                {
                    Console.WriteLine("Nessuna connessione al database!!");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
