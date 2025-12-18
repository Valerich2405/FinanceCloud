using FinanceCloud;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FirestoreService
{
    private FirestoreDb _db;

    public FirestoreService()
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"Resources\finance-track-bfabb-d9e7aada6f3f.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

        _db = FirestoreDb.Create("finance-track-bfabb");
    }

    public async Task AddExpense(Expense expense)
    {
        DocumentReference doc = _db.Collection("expenses").Document();
        expense.Id = doc.Id;
        await doc.SetAsync(expense);
    }

    public async Task<List<Expense>> GetExpenses()
    {
        QuerySnapshot snapshot = await _db.Collection("expenses").GetSnapshotAsync();

        var list = new List<Expense>();
        foreach (var doc in snapshot.Documents)
            list.Add(doc.ConvertTo<Expense>());

        return list;
    }

    public async Task DeleteExpense(string id)
    {
        await _db.Collection("expenses").Document(id).DeleteAsync();
    }

    public async Task AddIncome(Income income)
    {
        var localDate = income.Date.Date;
        income.Date = DateTime.SpecifyKind(localDate, DateTimeKind.Utc);

        DocumentReference doc = _db.Collection("incomes").Document();
        income.Id = doc.Id;
        await doc.SetAsync(income);
    }

    public async Task<List<Income>> GetIncomes()
    {
        QuerySnapshot snapshot = await _db.Collection("incomes").GetSnapshotAsync();
        var list = new List<Income>();

        foreach (var doc in snapshot.Documents)
            list.Add(doc.ConvertTo<Income>());

        return list;
    }

    public async Task DeleteIncome(string id)
    {
        await _db.Collection("incomes").Document(id).DeleteAsync();
    }

}
