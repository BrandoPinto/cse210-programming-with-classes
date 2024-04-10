namespace ProjectFinal
{
    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsBorrowed { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            IsBorrowed = true;
        }

        public void Return()
        {
            IsBorrowed = false;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }
}