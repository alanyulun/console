public class LC_501{
    public int[] FindMode(TreeNode root) {
        if(root==null)
            return new int[0];
        
        int maxCount=0;
        Dictionary<int,int> map=new Dictionary<int,int>();
        Queue<TreeNode> q=new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count>0){
            TreeNode n=q.Dequeue();

            if(!map.ContainsKey(n.val))
                map.Add(n.val,0);
            map[n.val]++;

            if(maxCount<map[n.val])
                maxCount=map[n.val];

            if(n.left!=null)
                q.Enqueue(n.left);
            if(n.right!=null)
                q.Enqueue(n.right);
        }

        return map.Where(m=>m.Value==maxCount).Select(m=>m.Key).ToArray();
    }
}