public class LC_655{
    string [][] treeMatrix;

    public IList<IList<string>> PrintTree(TreeNode root) {
        if(root==null)
            return null;

        int level=getLevel(root);
        int arrLen=0;
        for(int i=level;i>0;i--)
            arrLen+=(int)Math.Pow(2,i-1);
        
        treeMatrix=new string[level][];
        for(int i=0;i<treeMatrix.Length;i++)
            treeMatrix[i]=Enumerable.Repeat("",arrLen).ToArray();

        fillList(root,0,0,arrLen-1);
        List<IList<string>> rul=new List<IList<string>>();
        foreach(var item in treeMatrix)
            rul.Add(item.ToList());

        return rul;
    }

    private void fillList(TreeNode root,int level,int s,int e){
        if(root==null)
            return;
        
        int m=(e+s)/2;
        treeMatrix[level][m]=root.val.ToString();

        fillList(root.left,level+1,s,m-1);
        fillList(root.right,level+1,m+1,e);
    }

    private int getLevel(TreeNode node){
        if(node==null)
            return 0;

        return 1+Math.Max(getLevel(node.left),getLevel(node.right));
    }
}