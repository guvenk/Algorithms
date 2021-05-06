
namespace Algorithms
{
    public class TrieNode
    {
        public TrieNode[] Links { get; set; } = new TrieNode[26];
        public bool IsEnd { get; set; }
    }
    // Assuming only lowercase chars are used
    public class Trie
    {
        private readonly TrieNode _root;

        public Trie() => _root = new TrieNode();

        public void Insert(string word)
        {
            TrieNode node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                var temp = node.Links[ch - 'a'];
                if (temp is null)
                    node.Links[ch - 'a'] = new TrieNode();

                node = node.Links[ch - 'a'];
            }
            node.IsEnd = true;
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
            TrieNode node = _root;
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
