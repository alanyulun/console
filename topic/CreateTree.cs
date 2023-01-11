public class CreateTree{
    public TreeNode createTree(string treeData){
        if(treeData.Length==0)
            return null;

        string[] treeDataArr=treeData.Split(',');
        TreeNode rul=new TreeNode();
        Queue<int?> treeValQ=new Queue<int?>();
        Queue<TreeNode> treeQ=new Queue<TreeNode>();
        foreach(var val in treeDataArr){
            if(val=="null")
                treeValQ.Enqueue(null);
            else
                treeValQ.Enqueue(int.Parse(val));
        }
            
        rul.val=(int)treeValQ.Dequeue();
        treeQ.Enqueue(rul);

        while(treeQ.Count>0&&treeValQ.Count>0){
            int levelCount=treeQ.Count;

            for(int i=0;i<levelCount;i++){
                TreeNode node=treeQ.Dequeue();

                if(treeValQ.Count==0)
                    break;
                int? treeVal=treeValQ.Dequeue();
                if(treeVal!=null)
                    node.left=new TreeNode((int)treeVal);
                if(treeValQ.Count==0)
                    break;
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