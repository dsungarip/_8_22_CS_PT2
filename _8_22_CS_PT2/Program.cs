using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_22_CS_PT2_1_Tree
{
	//트리 구현해보기
	class TreeNode<T>
	{
		public T Data { get; set; }
		public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
	}
	internal class Program
	{
		static TreeNode<string> MakeTree()	//트리구현부
		{
			TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
			{
				{
					TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
					node.Children.Add(new TreeNode<string>() { Data = "전투" });
					node.Children.Add(new TreeNode<string>() { Data = "경제" });
					node.Children.Add(new TreeNode<string>() { Data = "스토리" });
					root.Children.Add(node);
				}
				{
					TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
					node.Children.Add(new TreeNode<string>() { Data = "서버" });
					node.Children.Add(new TreeNode<string>() { Data = "클라" });
					node.Children.Add(new TreeNode<string>() { Data = "엔진" });
					root.Children.Add(node);
				}
				{
					TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
					node.Children.Add(new TreeNode<string>() { Data = "배경" });
					node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
					root.Children.Add(node);
				}
			}
			return root;
		}

		static void PrintTree(TreeNode<string> root)	//트리출력함수
		{
			Console.WriteLine(root.Data);	//부모 출력후

			foreach (TreeNode<string> child in root.Children)
				PrintTree(child);	//재귀를 이용해서 자식에게 넘긴다.
		}

		static int GetHeight(TreeNode<string> root)	//트리 높이구하기 함수
		{
			int height = 0;
			foreach(TreeNode<string> child in root.Children)
			{
				int newHeight = GetHeight(child) + 1;
				height = Math.Max(height, newHeight);	//두 변수중 높은값을 반환
			}

			return height;
		}
		static void Main(string[] args)
		{
			TreeNode<string> root = MakeTree();
			PrintTree(root);

			Console.WriteLine();

			Console.WriteLine(GetHeight(root));
		}
	}
}
