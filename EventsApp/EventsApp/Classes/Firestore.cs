using System;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace EventsApp.Classes
{
    public static class Firestore
    {
        private static FirestoreDb DB = FirestoreDb.Create();

        public static async System.Threading.Tasks.Task insertEventAsync(Dictionary<string,object> eventData, string userId)
        {
            DocumentReference docRef = DB.Collection("users").Document(userId);
            await docRef.SetAsync(eventData);
        }

        public static async System.Threading.Tasks.Task<Dictionary<string, object>> getUserData(string userId)
        {
            DocumentReference userDoc = DB.Collection("users").Document(userId);
            DocumentSnapshot userSnapshot = await userDoc.GetSnapshotAsync();
            return userSnapshot.ToDictionary();
        }
    }
}
