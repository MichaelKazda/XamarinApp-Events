using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppRemastered.Database {
    public static class Firestore {
        private static FirestoreDb DB = FirestoreDb.Create();

        public static async Task insertEventAsync(Dictionary<string, object> eventData, string userId) {
            DocumentReference docRef = DB.Collection("users").Document(userId);
            await docRef.SetAsync(eventData);
        }

        public static async Task<Dictionary<string, object>> getUserData(string userId) {
            DocumentReference userDoc = DB.Collection("users").Document(userId);
            DocumentSnapshot userSnapshot = await userDoc.GetSnapshotAsync();
            return userSnapshot.ToDictionary();
        }
    }
}
