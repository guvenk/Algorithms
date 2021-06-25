
namespace Algorithms
{
    public class TrieNode
    {
        public string Word = null;
        public TrieNode[] Links { get; set; } = new TrieNode[26];
        public bool IsEnd { get; set; }

        public bool ContainsKey(char ch) => ch != '#' && Links[ch - 'a'] != null;
    }

    // Assuming only lowercase chars are used
    public class Trie
    {
        public readonly TrieNode Root;

        public Trie() => Root = new TrieNode();

        public void Insert(string word)
        {
            TrieNode node = Root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                var temp = node.Links[ch - 'a'];
                if (temp is null)
                    node.Links[ch - 'a'] = new TrieNode();

                node = node.Links[ch - 'a'];
            }
            node.IsEnd = true;
            node.Word = word;
        }


        public bool Search(string word)
        {
            var node = SearchPrefixWith(word);
            return node != null && node.IsEnd;
        }

        public bool StartsWith(string prefix)
        {
            return SearchPrefixWith(prefix) != null;
        }

        public TrieNode SearchPrefixWith(string prefix)
        {
            TrieNode node = Root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char ch = prefix[i];
                var temp = node.Links[ch - 'a'];
                if (temp is null)
                    return null;
                else
                    node = temp;
            }

            return node;
        }
    }
}
