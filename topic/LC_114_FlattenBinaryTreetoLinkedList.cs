public class LC_114{    
    public void Flatten(TreeNode root) {
        //solution1
        if(root!=null){
            TreeNode rootRTree=root.right;
            if(root.left!=null)
                root.right=root.left;
            else
                root.right=null;
            root.left=null;

            TreeNode rightLeaf=root;
            while(rightLeaf.right!=null)
                rightLeaf=rightLeaf.right;
            rightLeaf.right=rootRTree;
            
            Flatten(root.right);
        }
        
        //solution2
        // Queue<int> pre=preorder(root,new Queue<int>());

        // TreeNode rul=new TreeNode();
        // TreeNode targetNode=rul;
        // while(pre.Count>0){
        //     targetNode.val=pre.Dequeue();

        //     if(pre.Count>0){
        //         targetNode.right=new TreeNode();
        //         targetNode=targetNode.right;
        //     }
        // }

        // root=rul;
    }

    private Queue<int> preorder(TreeNode root,Queue<int> q)
    {
        if(root==null)
            return q;
        
        q.Enqueue(root.val);
        preorder(root.left,q);
        preorder(root.right,q);

        return q;
    }
}