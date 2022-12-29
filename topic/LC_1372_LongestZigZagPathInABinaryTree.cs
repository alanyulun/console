public class LC_1372{
    public int LongestZigZag(TreeNode root) {
        if(root==null)
            return 0;

        int maxLevel=countLevel(root);
        int lLevel=LongestZigZag(root.left);
        int rLevel=LongestZigZag(root.right);

        if(maxLevel<lLevel)
            maxLevel=lLevel;
        if(maxLevel<rLevel)
            maxLevel=rLevel;

        return maxLevel;
    }

    private int countLevel(TreeNode root){
        int maxLevel=0;

        for(int i=0;i<=1;i++){
            int dir=i;
            int zigZagLevel=0;
            TreeNode node=root;
            
            while(true){
                if(dir==0&&node.left!=null){
                    node=node.left;
                    zigZagLevel++;
                    dir=1;
                }
                else if(dir==1&&node.right!=null){
                    node=node.right;
                    zigZagLevel++;
                    dir=0;
                }
                else
                    break;
            }

            if(zigZagLevel>maxLevel)
                maxLevel=zigZagLevel;
        }

        return maxLevel;
    }
}