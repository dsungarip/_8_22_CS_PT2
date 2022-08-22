using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_22_CS_PT2_2_PriorityQueue
{	// 우선순위 큐
	class PriorityCueue<T> where T : IComparable<T>
	{
		List<T>_heap = new List<T>();
		public void Push(T data)  // 0(logN)
		{
			// 힙의 맨 끝에 새로운 데이터 삽임
			_heap.Add(data);

			int now = _heap.Count - 1;

			//도장깨기 시작
			while (now > 0)
			{
				//도장깨기를 시도
				int next = (now-1)/2;	//우선순위 힙의 부모클래스 공식 [ (현재 번호 - 1) / 2 ]
				if (_heap[now].CompareTo(_heap[next]) < 0)	//데이터가 부모보다 작을경우
					break;	

				//두 값을 교체한다.
				T temp = _heap[now];
				_heap[now] = _heap[next];
				_heap[next] = temp;

				// 검사 위치를 이동
				now = next;
			}
		}

		public T Pop()	// 0(logN)
		{
			// 반환할 데이터를 따로 저장
			T ret = _heap[0];

			// 마지막 데이터를 루트로 이동한다.
			int lastIndex = _heap.Count -1;
			_heap[0] = _heap[lastIndex];
			_heap.RemoveAt(lastIndex);
			lastIndex--;

			// 역으로 내려가는 도장깨기 시작
			int now = 0;
			while(true)
			{
				int left = 2*now+1;
				int right = 2*now+2;

				int next = now;
				//왼쪽값이 현재값보다 크면, 왼쪽으로 이동
				if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
					next = left;
				//오른값이 현재값(왼쪽이동포함)보다 크면, 오른쪽으로 이동
				if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
					next = right;

				//왼쪽/ 오른쪽 모두 현재값보다 작으면 종료
				if (next == now)
					break;

				//두 값을 교체한다.
				T temp = _heap[now];
				_heap[now] = _heap[next];
				_heap[next] = temp;
				//검사 위치를 이동
				now = next;
			}

			return ret;
		}
		public int Count()
		{
			return _heap.Count;
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			PriorityCueue<int> q = new PriorityCueue<int>();

			q.Push(20);
			q.Push(10);
			q.Push(30);
			q.Push(90);
			q.Push(40);

			while(q.Count() > 0)
			{
				Console.WriteLine(q.Pop());
			}
		}
	}
}