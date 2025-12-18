using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace FinanceCloud
{
    [FirestoreData]

    public class Expense
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty]
        public double Amount { get; set; }

        [FirestoreProperty]
        public string Category { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }

        [FirestoreProperty]
        public DateTime Date { get; set; }

        public Expense() { }
    }
}
