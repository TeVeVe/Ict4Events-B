using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharedClasses.Views
{
    public partial class UCTreeView : UserControl
    {
        private readonly List<TreeNode> _currentNodeMatches = new List<TreeNode>();

        private int _lastNodeIndex;

        private string _lastSearchText;

        public UCTreeView()
        {
            InitializeComponent();
        }

        public Action AddCategoryAction { get; set; }
        public Action AddSubcategoryAction { get; set; }

        public string SearchFilter
        {
            get { return textBoxSearchFilter.Text; }
            set
            {
                if (value == textBoxSearchFilter.Text) return;
                IEnumerable<TreeNode> nodes = treeViewCategories.Nodes.Cast<TreeNode>();
            }
        }

        private void textBoxSearchFilter_TextChanged(object sender, EventArgs e)
        {
            var textBox = ((TextBox)sender);

            string searchText = textBox.Text;
            if (String.IsNullOrEmpty(searchText))
                return;
            ;


            if (_lastSearchText != searchText)
            {
                //It's a new Search
                _currentNodeMatches.Clear();
                _lastSearchText = searchText;
                _lastNodeIndex = 0;
                SearchNodes(searchText, treeViewCategories.Nodes[0]);
            }

            if (_lastNodeIndex >= 0 && _currentNodeMatches.Count > 0 && _lastNodeIndex < _currentNodeMatches.Count)
            {
                TreeNode selectedNode = _currentNodeMatches[_lastNodeIndex];
                _lastNodeIndex++;
                SelectNode(selectedNode);
            }
        }

        private void SearchNodes(string SearchText, TreeNode StartNode)
        {
            TreeNode node = null;
            while (StartNode != null)
            {
                if (StartNode.Text.ToLower().Contains(SearchText.ToLower()))
                    _currentNodeMatches.Add(StartNode);
                ;
                if (StartNode.Nodes.Count != 0)
                    SearchNodes(SearchText, StartNode.Nodes[0]); //Recursive Search 
                ;
                StartNode = StartNode.NextNode;
            }
            ;
        }

        private void treeViewCategories_KeyDown(object sender, KeyEventArgs e)
        {
            if (treeViewCategories.Nodes.Count <= 0) return;

            int keyValue = e.KeyValue;
            e.SuppressKeyPress = true;

            char key;
            if (!e.Shift && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
                key = (char)(keyValue + 32);
            else
                key = (char)keyValue;

            if (Regex.IsMatch(key.ToString(CultureInfo.InvariantCulture), @"\w"))
                textBoxSearchFilter.Text += key;
            else
            {
                if (e.KeyData == Keys.Back && textBoxSearchFilter.TextLength > 0)
                    textBoxSearchFilter.Text = textBoxSearchFilter.Text.Substring(0, textBoxSearchFilter.TextLength - 1);
                else if (e.KeyData.HasFlag(Keys.Enter))
                {
                    // Search next node.
                    _currentNodeMatches.Clear();
                    SearchNodes(textBoxSearchFilter.Text, treeViewCategories.Nodes[0]);

                    List<TreeNode>.Enumerator enumerator = _currentNodeMatches.GetEnumerator();
                    while (treeViewCategories.SelectedNode != enumerator.Current)
                        enumerator.MoveNext();

                    TreeNode selectedNewItem = null;
                    if (e.KeyData.HasFlag(Keys.Shift))
                    {
                        TreeNode item = enumerator.Current;
                        int index = _currentNodeMatches.IndexOf(item) - 1;
                        if (index >= 0)
                            selectedNewItem = _currentNodeMatches.ElementAt(index);
                        else
                            selectedNewItem = _currentNodeMatches.Last();
                    }
                    else
                    {
                        enumerator.MoveNext();
                        selectedNewItem = enumerator.Current ?? _currentNodeMatches.First();
                    }

                    SelectNode(selectedNewItem);
                }
                else
                    e.SuppressKeyPress = false;
            }

            textBoxSearchFilter.Select(textBoxSearchFilter.TextLength, 1);
        }

        private void SelectNode(TreeNode node)
        {
            treeViewCategories.SelectedNode = node;
            treeViewCategories.SelectedNode.Expand();
            treeViewCategories.Select();
            treeViewCategories.SelectedNode.EnsureVisible();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            if (AddCategoryAction == null) return;
            AddCategoryAction();
        }

        private void buttonAddSubcategory_Click(object sender, EventArgs e)
        {
            if (AddSubcategoryAction == null) return;
            AddSubcategoryAction();
        }
    }
}