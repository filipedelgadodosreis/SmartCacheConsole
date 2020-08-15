using ConsoleAppTransaction.Models;
using ConsoleAppTransaction.Repositories;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace ConsoleAppTransaction
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MessageRepository messageRepository;

                messageRepository = new MessageRepository();
                messageRepository.OnNewMessage += MessageRepository_OnNewMessage;

                //Task.Run(() => messageRepository.Start(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString));

                messageRepository.Start(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.ReadKey();
        }

        private static async void MessageRepository_OnNewMessage(Message message)
        {
            Console.WriteLine($"{message.Data}\t{message.Symbol}");
            await Processar(message);
        }

        private static async Task Processar(Message message)
        {
            //List<Book> lstBooks = new List<Book>();

            switch (message.ExchangeVenda)
            {
                case "Poloniex":
                    //lstBooks = await ApiPoloniex.BuscarBook(message.Symbol);
                    break;
                default:
                    break;
            }
            //Percorre o book para buscar a melhor oportunidade 
            //for (int i = 0; i < lstBooks.Count; i++)
            //{

            //}
        }
    }
}
