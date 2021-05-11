using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Pipes;


namespace Chess2_redo
{
    public class PipeServer
    {
   
        public void sendData(string result)
        {
            using (NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("chess-pipe-1", PipeDirection.InOut))
            {

                Console.WriteLine("trying to get connected.");
                pipeServer.WaitForConnection();

                Console.WriteLine("Client connected.");
                try
                {
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine(result);

                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }

                pipeServer.Dispose();
            }
        }


        public void reciveData()
        {
            using (NamedPipeClientStream pipeClient =
                  new NamedPipeClientStream(".", "chess-pipe-2", PipeDirection.InOut))
            {

                // Connect to the pipe or wait until the pipe is available.
                Console.Write("Attempting to connect to pipe...");
                pipeClient.Connect();

                Console.WriteLine("Connected to pipe.");
                Console.WriteLine("There are currently {0} pipe server instances open.",
                   pipeClient.NumberOfServerInstances);


                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    // Display the read text to the console
                    //List<string> temp2;

                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {   
                        //temp = sr.ReadLine();
                        string[] temp3 = temp.Split(',');
                        Console.WriteLine("Received from server: {0}", temp3[0]);

                        if (temp != null)
                        {
                            Program.game.userInput = temp3[0];
                            Console.WriteLine("length: " + temp3.Length);
                            if (temp3.Length == 4) {
                                Program.game.setCord(int.Parse(temp3[1]), int.Parse(temp3[2]));
                                Program.game.setCurrentPiece(temp3[3]);
                                Program.game.setCurrentPlayer();
                            }
                        }      
                    }
                    pipeClient.Dispose();

                }
            }
        }
    }
}
