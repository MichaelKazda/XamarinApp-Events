using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace EventsApp.Classes
{
    public static class Firestore
    {
        private static FirestoreDb db = FirestoreDb.Create();

        public static async Task insertEventAsync(Dictionary<string,object> eventData, string userId)
        {
            DocumentReference docRef = db.Collection("users").Document(userId);
            await docRef.SetAsync(eventData);
        }

        public static async Task<Dictionary<string, object>> getUserData(string userId)
        {
            DocumentReference userDoc = db.Collection("users").Document(userId);
            DocumentSnapshot userSnapshot = await userDoc.GetSnapshotAsync();
            return userSnapshot.ToDictionary();
        }
    }
}
