public class LC_337{
    public int Rob(TreeNode root) {
        if(root==null)
            return 0;
        
        Dictionary<TreeNode,int> hashmap=new Dictionary<TreeNode,int>();
        return maxRobVal(root,hashmap);
    }

    private int maxRobVal(TreeNode root,Dictionary<TreeNode,int> hashmap){
        if(root==null)
            return 0;

        if(hashmap.ContainsKey(root))
            return hashmap[root];

        int val=root.val;
        if(root.left!=null)
            val+=maxRobVal(root.left.left,hashmap)+maxRobVal(root.left.right,hashmap);
        if(root.right!=null)
            val+=maxRobVal(root.right.left,hashmap)+maxRobVal(root.right.right,hashmap);
        val=Math.Max(val,maxRobVal(root.left,hashmap)+maxRobVal(root.right,hashmap));

        hashmap[root]=val;
        return val;
    }
}