CC = gcc
CFLAGS = -Wall -std=c11

SRC = $(wildcard src/*.c)
OBJ = $(SRC:src/%.c=build/%.o)

all: program

build/%.o: src/%.c | build
	$(CC) $(CFLAGS) -Iinclude -c $< -o $@

program: $(OBJ)
	$(CC) $(CFLAGS) -o program $(OBJ)

build:
	mkdir build

clean:
	del /Q build\*.o program.exe
