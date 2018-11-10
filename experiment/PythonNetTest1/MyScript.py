#!/usr/bin/env python
# -*- coding: utf-8 -*-
import sys
import os

def Calculate(a, b):
    return a*b;

def TestFunction(path, content):
    file = os.open(path, 0666)
    os.write(file, content)
    os.close(file)
