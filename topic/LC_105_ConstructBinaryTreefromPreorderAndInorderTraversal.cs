//樹還原 前序+中序
public class LC_105{
    public TreeNode createBiTree(int[] preorder, int[] inorder, int len)
    {
        if (len == 0)
            return null;

        TreeNode rul = new TreeNode();
        rul.val = preorder[0];
        int rootIndex = Array.IndexOf(inorder, rul.val);
        int[] lPreorder = new int[rootIndex], lInorder = new int[rootIndex];
        int[] rPreorder = new int[len - rootIndex - 1], rInorder = new int[len - rootIndex - 1];
        Array.Copy(preorder, 1, lPreorder, 0, lPreorder.Length);
        Array.Copy(preorder, rootIndex + 1, rPreorder, 0, rPreorder.Length);
        Array.Copy(inorder, 0, lInorder, 0, lInorder.Length);
        Array.Copy(inorder, rootIndex + 1, rInorder, 0, rInorder.Length);

        rul.left = createBiTree(lPreorder, lInorder, lPreorder.Length);
        rul.right = createBiTree(rPreorder, rInorder, rPreorder.Length);

        return rul;
    }
}