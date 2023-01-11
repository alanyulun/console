public class LC_450{
    public TreeNode DeleteNode(TreeNode root, int key) {
        if(root==null)
            return null;

        if(key>root.val)
            root.right=DeleteNode(root.right,key);
        else if(key<root.val)
            root.left=DeleteNode(root.left,key);
        else{
            if(root.left==null&&root.right==null)
                return null;
            else if(root.left!=null){
                root.val=findMax(root.left);
                root.left=DeleteNode(root.left,root.val);
            }
            else{
                root.val=findMin(root.right);
                root.right=DeleteNode(root.right,root.val);
            }
        }

        return root;
    }

    private int findMax(TreeNode root){
        while(root.right!=null)
            root=root.right;
        return root.val;
    }

    private int findMin(TreeNode root){
        while(root.left!=null)
            root=root.left;
        return root.val;
    }
}