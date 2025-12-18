using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCloud
{
    using Google.Cloud.Firestore;

    [FirestoreData]
    public class Income
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty]
        public double Amount { get; set; }

        [FirestoreProperty]
        public string Source { get; set; }  

        [FirestoreProperty]
        public string Description { get; set; }

        [FirestoreProperty]
        public DateTime Date { get; set; }

        public Income() { }
    }
}
