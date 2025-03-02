CXXFLAGS = -std=c++17 -I./include/ -g0
CXXFLAGS = -std=c++17 -I./include/ -g0 -finput-charset=UTF-8 -fexec-charset=UTF-8


RUN: derleme bagla calistir

derleme:
	g++ -c -I "./include/" ./src/main.cpp -o ./lib/main.o
	g++ -c -I "./include/" ./src/Genler.cpp -o ./lib/Genler.o
	g++ -c -I "./include/" ./src/IndexNode.cpp -o ./lib/IndexNode.o
	g++ -c -I "./include/" ./src/Kromozom.cpp -o ./lib/Kromozom.o
	g++ -c -I "./include/" ./src/Populasyon.cpp -o ./lib/Populasyon.o
	g++ -c -I "./include/" ./src/utils.cpp -o ./lib/utils.o
bagla:
	g++ ./lib/main.o ./lib/Genler.o ./lib/IndexNode.o ./lib/Kromozom.o ./lib/Populasyon.o ./lib/utils.o -o ./bin/program.exe
calistir:
	./bin/program.exe
