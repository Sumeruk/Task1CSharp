using System;

namespace BookLibrary
{
    public class BookInformation
    {
        public string BookId { get; private set; }
        public string BookName { get; private set; }
        public string Authors { get; private set; }
        public int Pages { get; private set; }
        public string Genre { get; private set; }
        public State CurrentState { get; private set; }

        public BookInformation(string bookId, string bookName, string authors, int pages, string genre, State currentState)
        {
            if(pages < 1)
            {
                throw new ArgumentException("Нельзя создать книгу с таким количеством страниц");
            }

            if(bookId == null || bookName == null)
            {
                throw new ArgumentException("Заполните поля!");
            }
            BookId = bookId;
            BookName = bookName;
            Authors = authors;
            Pages = pages;
            Genre = genre;
            CurrentState = currentState;
        }

        public override string ToString()
        {
            return $"Книга: Код учета - {BookId} " +
               $"Название - {BookName} " +
               $"Авторы - {Authors} " +
               $"Количество страниц - {Pages} " +
               $"Тематика - {Genre} " +
               $"Состояние - {CurrentState}";
        }

        public string ChangeBookId(string newBookId)
        {
            BookId = newBookId;
            return $"Книга: Код учета - {BookId} " +
               $"Название - {BookName} " +
               $"Авторы - {Authors} " +
               $"Количество страниц - {Pages} " +
               $"Тематика - {Genre} " +
               $"Состояние - {CurrentState}";
        }

        public string ChangeState(State newState)
        {
            CurrentState = newState;
            return $"Книга: Код учета - {BookId} " +
               $"Название - {BookName} " +
               $"Авторы - {Authors} " +
               $"Количество страниц - {Pages} " +
               $"Тематика - {Genre} " +
               $"Состояние - {CurrentState}";
        }
    }
}
