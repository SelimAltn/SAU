CXX = g++
CXXFLAGS = -std=c++17 -I./include/ -g0 -finput-charset=UTF-8 -fexec-charset=UTF-8

RUN: derleme bagla calistir

derleme:
	$(CXX) -c -I "./include/" ./src/main.cpp -o ./lib/main.o
	$(CXX) -c -I "./include/" ./src/FileManager.cpp -o ./lib/FileManager.o
	$(CXX) -c -I "./include/" ./src/LinkedList.cpp -o ./lib/LinkedList.o
	$(CXX) -c -I "./include/" ./src/TreeNode.cpp -o ./lib/TreeNode.o
	$(CXX) -c -I "./include/" ./src/Processor.cpp -o ./lib/Processor.o

bagla:
	$(CXX) ./lib/main.o ./lib/FileManager.o ./lib/LinkedList.o ./lib/TreeNode.o ./lib/Processor.o -o ./bin/program.exe

calistir:
	./bin/program.exe

clean:
	rm -f ./lib/*.o ./bin/program.exe
