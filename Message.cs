namespace Framework2
{
    public class Message
    {

        public Message(string email, string order, string file, string message)
        {
            Email = email;
            Order = order;
            File = file;
            MessageBody = message;
        }

        public string Email { get; }
        public string Order { get; }
        public string File { get; }
        public string MessageBody { get; }
    }
}