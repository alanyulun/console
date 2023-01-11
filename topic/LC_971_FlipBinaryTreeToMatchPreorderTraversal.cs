public class LC_971{
    int n=0;

    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage) {
        List<int> list = new List<int>();
        if(find(root, voyage, list))
            return list;
        list = new List<int>();
        list.Add(-1);
        return list;
    }

    private bool find(TreeNode root, int[] voyage, List<int> list) {
        if (root==null)
            return true;
            
        if (n==voyage.Length||root.val!=voyage[n])
            return false;
        n++;
        if (find(root.left,voyage,list)&&find(root.right,voyage,list))
            return true;
        list.Add(root.val);
        if (find(root.right,voyage,list)&&find(root.left,voyage,list))
            return true;
        n--;
        list.Remove(list.Count()-1);
        return false;
    }
}