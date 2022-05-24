using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Demo
{
    public interface IPrintable
    {
        void Print();

        void PrintToPdf();
    }

    public interface ISaveable
    {
        void SaveToFile(string fileName);
    }

    public interface IDocument : ISaveable, IPrintable
    {
        void CreateNewDocument();
    }

    public class PdfDocument : IDocument
    {
        public void CreateNewDocument()
        {
        }

        public void Print()
        {
            Console.WriteLine("Hello from PdfDocument class");
        }

        public void PrintToPdf()
        {
        }

        public void SaveToFile(string fileName)
        {
        }
    }

    public class WordDocumnet : IPrintable, ISaveable, IEquatable<WordDocumnet>
    {
        public bool Equals([AllowNull] WordDocumnet other)
        {
            throw new NotImplementedException();
        }

        // error
        //private void Pring()
        //{ 

        //}

        public void Print()
        {
            Console.WriteLine("Hello from Document class");
        }

        public void PrintToPdf()
        {

        }

        public void SaveToFile(string fileName)
        { 
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IPrintable p = new WordDocumnet();
            p.Print();
            p = new PdfDocument();
            p.PrintToPdf();

            Print(new WordDocumnet());
            Print(new PdfDocument());

            List<IPrintable> printable = new List<IPrintable>();

            printable.Add(new WordDocumnet());
            printable.Add(new PdfDocument());
            printable.Add(new WordDocumnet());

        }

        static void Print(IPrintable printable)
        { 
            
        }
    }
}
