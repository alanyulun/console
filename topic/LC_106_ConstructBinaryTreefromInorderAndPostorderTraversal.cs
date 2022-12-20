//樹還原 中序+後序
public class LC_106{
    public TreeNode createBiTree(int[] inorder, int[] postorder, int len)
    {
        if (len == 0)
            return null;

        TreeNode rul = new TreeNode();
        rul.val = postorder[len - 1];
        int rootIndex = Array.IndexOf(inorder, rul.val);
        int[] lPostorder = new int[rootIndex], lInorder = new int[rootIndex];
        int[] rPostorder = new int[len - rootIndex - 1], rInorder = new int[len - rootIndex - 1];
        Array.Copy(postorder, 0, lPostorder, 0, lPostorder.Length);
        Array.Copy(postorder, rootIndex, rPostorder, 0, rPostorder.Length);
        Array.Copy(inorder, 0, lInorder, 0, lInorder.Length);
        Array.Copy(inorder, rootIndex + 1, rInorder, 0, rInorder.Length);

        rul.left = createBiTree(lInorder, lPostorder, lPostorder.Length);
        rul.right = createBiTree(rInorder, rPostorder, rPostorder.Length);

        return rul;
    }
}