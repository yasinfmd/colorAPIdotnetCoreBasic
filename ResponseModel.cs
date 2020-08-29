namespace dotnettest
{
    public  class ResponseModel<T>
    {

        public ResponseModel()
        {
        }

        public ResponseModel(bool Status)
        {
            this.Status = Status;
        }

        public ResponseModel(T Result, string Message, bool Status)
        {
            this.Result = Result;
            this.Message = Message;
            this.Status = Status;
        }
        public T Result { get; set; }
        public string Message { get; set; }

        public bool Status { get; set; }
    }
}