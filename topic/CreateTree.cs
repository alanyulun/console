public class CreateTree{
    public TreeNode createTree(int?[] treeValList){
        if(treeValList.Length==0)
            return null;

        TreeNode rul=new TreeNode();
        Queue<int?> treeValQ=new Queue<int?>();
        Queue<TreeNode> treeQ=new Queue<TreeNode>();
        foreach(var val in treeValList)
            treeValQ.Enqueue(val);
        rul.val=(int)treeValQ.Dequeue();
        treeQ.Enqueue(rul);

        while(treeQ.Count>0&&treeValQ.Count>0){
            int levelCount=treeQ.Count;

            for(int i=0;i<levelCount;i++){
                TreeNode node=treeQ.Dequeue();

                int? treeVal=treeValQ.Dequeue();
                if(treeVal!=null)
                    node.left=new TreeNode((int)treeVal);
                treeVal=treeValQ.Dequeue();
                if(treeVal!=null)
                    node.right=new TreeNode((int)treeVal);

                if(node.left!=null)
                    treeQ.Enqueue(node.left);
                if(node.right!=null)
                    treeQ.Enqueue(node.right);
            }
        }

        return rul;
    }
}