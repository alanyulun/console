public class LC_437{
    int rul=0;

    public int PathSum(TreeNode root, int targetSum) {
        preorder(root,targetSum);

        return rul;
    }

    private void preorder(TreeNode root,int targetSum){
        if(root==null)
            return;
        
        findTargetSum(root,targetSum,0);
        preorder(root.left,targetSum);
        preorder(root.right,targetSum);
    }

    private void findTargetSum(TreeNode root,int targetSum,Int64 currentSum){
        if(root==null)
            return;
        
        currentSum+=root.val;
        if(currentSum==targetSum)
            rul++;
        findTargetSum(root.left,targetSum,currentSum);
        findTargetSum(root.right,targetSum,currentSum);
    }
}