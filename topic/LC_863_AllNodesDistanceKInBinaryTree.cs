public class LC_863{
    List<int> res=new List<int>();
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        Helper(root,target,k);

        return res;
    }

    public int Helper(TreeNode root, TreeNode target, int k)
    {
        if(root==null)
            return -1;
        
        if(root==target)
        {
            GetAns(root,k);
            return 0;
        }

        int l=Helper(root.left,target,k);
        int r=Helper(root.right,target,k);
        if(l>=0)
        {
            if(l==k-1)
                res.Add(root.val);
            else{
                GetAns(root.right,k-l-2);
                return l+1;
            }
        }

        if(r>=0)
        {
            if(r==k-1)
                res.Add(root.val);
            else{
                GetAns(root.left,k-r-2);
                return r+1;
            }
        }

        return -1;
    }

    public void GetAns(TreeNode root, int k)
    {
        if(root==null || k<0)
            return;
        
        if(k==0)
            res.Add(root.val);

        GetAns(root.left,k-1);
        GetAns(root.right,k-1);
        
    }
}