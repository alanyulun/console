public class LC_538{
    public TreeNode ConvertBST(TreeNode root) {
        List<int> order=inorder(root);
        Stack<int> s=new Stack<int>();
        for(int i=order.Count-1;i>=0;i--){
            if(i!=order.Count-1)
                order[i]+=order[i+1];
            s.Push(order[i]);
        }
        
        root=convertTree(root,s);

        return root;
    }

    private TreeNode convertTree(TreeNode root,Stack<int> s){
        if(root==null)
            return null;
        
        root.left=convertTree(root.left,s);
        root.val=s.Pop();
        root.right=convertTree(root.right,s);

        return root;
    }

    private List<int> inorder(TreeNode root){
        List<int> rul=new List<int>();

        if(root==null)
            return rul;
        
        rul.AddRange(inorder(root.left));
        rul.Add(root.val);
        rul.AddRange(inorder(root.right));

        return rul;
    }
}