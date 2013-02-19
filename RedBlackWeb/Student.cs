﻿using RedBlack;

namespace RedBlackWeb
{
    public class Student : ITreeObject
    {
        private string key;

        public Student(string key)
        {
            this.key = key;
        }

        public string GetObjectStorageKey()
        {
            return key;
        }
    }
}