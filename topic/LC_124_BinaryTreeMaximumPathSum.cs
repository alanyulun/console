public class LC_124{
    int maxVal=int.MinValue;

    public int MaxPathSum(TreeNode root) {
        compare(root);
        
        return maxVal;
    }

    private int compare(TreeNode node){
        if(node==null)
            return 0;

        int lVal=compare(node.left);
        int rVal=compare(node.right);
        int cMaxVal=Math.Max(node.val,Math.Max((node.val+lVal+rVal),Math.Max(node.val+lVal,node.val+rVal)));
        if(maxVal<cMaxVal)
            maxVal=cMaxVal;

        return Math.Max(node.val,Math.Max(node.val+lVal,node.val+rVal));
    }
}