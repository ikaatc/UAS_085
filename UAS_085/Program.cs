using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UAS_085
{
    class Node
    {
        public int id, notelp;
        public string kelamin, nm;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNode()
        {
            int id, notelp;
            string kelamin, nm;
            Console.Write("\nMasukkan Id Pelanggan: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Pelanggan: ");
            nm = Console.ReadLine();
            Console.Write("Masukkan Jenis Kelamin: ");
            kelamin = Console.ReadLine();
            Console.Write("Masukkan Nomor Telepon: ");
            notelp = Convert.ToInt32(Console.ReadLine());

            Node nodeBaru = new Node();
            nodeBaru.id = id;
            nodeBaru.notelp = notelp;
            nodeBaru.nm = nm;
            nodeBaru.kelamin = kelamin;

            if (START == null || id <= START.id)
            {
                if ((START != null) && (id == START.id))
                {
                    Console.WriteLine("\nID SAMA TIDAK DIIJINKAN");
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (id >= current.id))
            {
                if (id == current.id)
                {
                    Console.WriteLine("\nID SAMA TIDAK DIIJINKAN");
                    return;
                }
                previous = current;
                current = current.next;
            }
            nodeBaru.next = current;
            previous.next = nodeBaru;
        }
        public bool Search(string nm, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (nm != current.nm))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nDATA KOSONG\n");
            else
            {
                Console.WriteLine("\nDATA DIDALAM LIST");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.WriteLine("\nId Pelanggan: " + currentNode.id + "\nNama Pelanggan: " + currentNode.nm +
                        "\nJenis Kelamin: " + currentNode.kelamin + "\nNomor Telepon: " + currentNode.notelp);
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu\n");
                    Console.WriteLine("1. Menambah Data");
                    Console.WriteLine("2. Melihat Semua Data");
                    Console.WriteLine("3. Mencari Data");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nMasukkan pilihan anda (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nDATA KOSONG\n");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Nama Pelanggan Yang Ingin Dicari: ");
                                string num = Console.ReadLine();
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nData Tidak Ditemukan\n");
                                else
                                {
                                    Console.WriteLine("\nData Ditemukan\n");
                                    Console.WriteLine("Id Pelanggan: " + current.id);
                                    Console.WriteLine("Nama Pelanggan: " + current.nm);
                                    Console.WriteLine("Jenis Kelamin: " + current.kelamin);
                                    Console.WriteLine("Nomor Telepon: " + current.notelp);
                                }
                            }
                            break;
                        case '4':
                            {
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("\nPilihan Tidak Valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck Nilai Yang Dimasukkan");
                }
            }
        }
    }
}



//  2.  Singly Linked List, karena ingin membuat list data dan bisa memasukkan data tanpa ada batasnya, juga dapat mencari no telp menggunakan nama pelanggan
//
//  3.  Ditambah diakhir = rear
//      Dihapus diakhir = front
//
//  4.  Array, memasukkan data, digunakan jika data nya ada isi maksimalnya atau ada batasnya, misal ingin punya 10 data, jadi cuman bisa masukin 10 data aja gak lebih
//      Linked list, mengurutkan suatu data, membuat list data, digunakan jika ingin memasukkan data tanpa ada batasnya
//
//  5.  a.  sibling (10 -> 30), (5 -> 15), (10 -> 15), (20 -> 32), (20 -> 28)
//      b.  preorder = 20, 10, 5, 15, 10, 12, 15, 18, 16, 30, 20, 20, 25, 20, 28, 32
//          inorder = 10, 5, 10, 12, 15, 15, 16, 18, 20, 20, 20, 20, 25, 28, 30, 32