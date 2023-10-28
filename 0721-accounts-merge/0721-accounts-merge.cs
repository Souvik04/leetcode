public class Solution
{
    HashSet<string> visited;
    Dictionary<string, IList<string>> map;

    public IList<IList<string>> AccountsMerge(IList<IList<string>> accountList){
        // create graph of adjacent emails
        map = new Dictionary<string, IList<string>>();
        visited = new HashSet<string>();

        foreach(var acc in accountList){
            string firstEmail = acc[1];

            for(int i = 2; i < acc.Count; i++){
                string nextEmail = acc[i];

                if(!map.ContainsKey(firstEmail)){
                    map[firstEmail] = new List<string>();
                }

                map[firstEmail].Add(nextEmail);

                if(!map.ContainsKey(nextEmail)){
                    map[nextEmail] = new List<string>();
                }

                map[nextEmail].Add(firstEmail);
            }
        }

        // traverse over the accountList and store components
        IList<IList<string>> mergedAccounts = new List<IList<string>>();
        foreach(var acc in accountList){
            string accountName = acc[0];
            string firstEmail = acc[1];

            if(!visited.Contains(firstEmail)){
                List<string> mergedAccount = new List<string>();
                mergedAccount.Add(accountName);
                DFS(mergedAccount, firstEmail);
                mergedAccount.Sort(1, mergedAccount.Count - 1, StringComparer.Ordinal);
                mergedAccounts.Add(mergedAccount);
            }
        }

        return mergedAccounts;
    }

    private void DFS(IList<string> mergedAccount, string email){
        visited.Add(email);
        mergedAccount.Add(email);
        
        if(!map.ContainsKey(email)){
            return;
        }

        foreach(string neighbour in map[email]){
            if(!visited.Contains(neighbour)){
                DFS(mergedAccount, neighbour);
            }
        }
    }
}


/*

1. create map of email with first email as key
2. iterate over each accounts and check if 


["John","johnsmith@mail.com","john_newyork@mail.com"]
["John","johnsmith@mail.com","john00@mail.com"]
["Mary","mary@mail.com"]
["John","johnnybravo@mail.com"]

["John","john00@mail.com","john_newyork@mail.com","johnsmith@mail.com"],
["Mary","mary@mail.com"],
["John","johnnybravo@mail.com"]


*/