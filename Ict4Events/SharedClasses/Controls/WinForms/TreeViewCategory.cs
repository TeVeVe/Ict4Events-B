using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class TreeViewCategory : UserControl
    {
        private readonly List<TreeNode> _currentNodeMatches;

        private int _lastNodeIndex;

        private string _lastSearchText;

        public TreeViewCategory()
        {
            InitializeComponent();
            _currentNodeMatches = new List<TreeNode>();
        }

        /// <summary>
        ///     Returns the collection which is used by the TreeView.
        /// </summary>
        [Browsable(false)]
        public TreeNodeCollection Nodes
        {
            get { return treeViewCategories.Nodes; }
        }

        public TreeNode SelectedNode
        {
            get { return treeViewCategories.SelectedNode; }
        }

        public string SearchFilter
        {
            get { return textBoxSearchFilter.Text; }
            set
            {
                // Checking early for possible errors.
                if (treeViewCategories.Nodes.Count <= 0) return;

                TextBox textBox = textBoxSearchFilter;

                string searchText = textBox.Text;
                if (String.IsNullOrEmpty(searchText))
                    return;

                if (_lastSearchText != searchText)
                {
                    // It's a new Search
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
        }

        /// <summary>
        ///     Triggers on button "Add category".
        /// </summary>
        public event EventHandler CategoryClick;

        public event EventHandler<TreeNodeMouseClickEventArgs> NodeClick;

        protected virtual void OnNodeClick(TreeNodeMouseClickEventArgs e)
        {
            EventHandler<TreeNodeMouseClickEventArgs> handler = NodeClick;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnCategoryClick()
        {
            EventHandler handler = CategoryClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Triggers on button "Add subcategory".
        /// </summary>
        public event EventHandler SubcategoryClick;

        protected virtual void OnSubcategoryClick()
        {
            EventHandler handler = SubcategoryClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void textBoxSearchFilter_TextChanged(object sender, EventArgs e)
        {
            // Code for filtered is in the property "SearchFilter".
            SearchFilter = textBoxSearchFilter.Text;
        }

        /// <summary>
        ///     Loops through all nodes recursively.
        /// </summary>
        /// <param name="SearchText">Text to match on every node.</param>
        /// <param name="StartNode">Node to start searching from (this node is included in the search).</param>
        private void SearchNodes(string SearchText, TreeNode StartNode)
        {
            while (StartNode != null)
            {
                // Matching..
                if (StartNode.Text.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    _currentNodeMatches.Add(StartNode);

                // If node contains childnodes. Search those too.
                if (StartNode.Nodes.Count != 0)
                    SearchNodes(SearchText, StartNode.Nodes[0]);

                // Goto next node (equals null when no next node. While loop will exit).
                StartNode = StartNode.NextNode;
            }
        }

        private void treeViewCategories_KeyDown(object sender, KeyEventArgs e)
        {
            if (treeViewCategories.Nodes.Count <= 0) return;

            int keyValue = e.KeyValue;

            // Say to Windows that this key is handled here. Don't send it further on the event stack.
            e.SuppressKeyPress = true;

            // Determine if the key should be uppercase or lowercase.
            char key;
            if (!e.Shift && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
                key = (char)(keyValue + 32);
            else
                key = (char)keyValue;


            // Match for only valid characters in textbox.
            if (Regex.IsMatch(key.ToString(CultureInfo.InvariantCulture), @"[a-zA-Z0-9]"))
                textBoxSearchFilter.Text += key;
            else
            {
                // Allow backspace.
                if (e.KeyData == Keys.Back && textBoxSearchFilter.TextLength > 0)
                    textBoxSearchFilter.Text = textBoxSearchFilter.Text.Substring(0, textBoxSearchFilter.TextLength - 1);
                    // Allow next node from current selection.
                else if (e.KeyData.HasFlag(Keys.Enter))
                {
                    // Search next node.
                    _currentNodeMatches.Clear();
                    SearchNodes(textBoxSearchFilter.Text, treeViewCategories.Nodes[0]);

                    // Move enumerator to current selection.
                    List<TreeNode>.Enumerator enumerator = _currentNodeMatches.GetEnumerator();
                    while (treeViewCategories.SelectedNode != enumerator.Current)
                        enumerator.MoveNext();

                    // Select next (or previous) node.
                    TreeNode selectedNewItem = null;
                    if (e.KeyData.HasFlag(Keys.Shift))
                    {
                        // Invert selection when shift is holded.
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

                    // Select the new node.
                    SelectNode(selectedNewItem);
                }
                else
                    e.SuppressKeyPress = false;
            }

            // Move cursor to end of textbox.
            textBoxSearchFilter.Select(textBoxSearchFilter.TextLength, 1);
        }

        /// <summary>
        ///     Selects the node in the TreeView and expands it.
        /// </summary>
        /// <param name="node">Node to be selected.</param>
        private void SelectNode(TreeNode node)
        {
            treeViewCategories.SelectedNode = node;
            treeViewCategories.SelectedNode.Expand();
            treeViewCategories.Select();
            treeViewCategories.SelectedNode.EnsureVisible();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            OnCategoryClick();
        }

        private void buttonAddSubcategory_Click(object sender, EventArgs e)
        {
            OnSubcategoryClick();
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewCategories.ExpandAll();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewCategories.CollapseAll();
        }

        private void treeViewCategories_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OnNodeClick(e);
        }
    }
}