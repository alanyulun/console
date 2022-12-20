public class LC_113 {
    List<IList<int>> rul;
    int nodeSum=0;

    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        rul=new List<IList<int>>();

        List<int> solution=new List<int>();
        DFS(root, targetSum, solution);

        return rul;
    }

    private void DFS(TreeNode node, int targetSum, List<int> solution){
        if(node==null||nodeSum>targetSum)
            return;
        
        nodeSum+=node.val;
        solution.Add(node.val);
        if(node.left==null&&node.right==null&&nodeSum==targetSum)
            rul.Add(new List<int>(solution));
        DFS(node.left,targetSum,solution);
        DFS(node.right,targetSum,solution);

        nodeSum-=node.val;
        solution.RemoveAt(solution.Count-1);
    }
}