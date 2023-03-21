DOTNET := dotnet
CSC := dotnet csc

SRCBACK := ../../../src/class/Back.cs
SRCDRIVER := Driver.cs

BACKDLL := bin/Back.dll
OUTPUT := -out:$(BACKDLL)

all:
	@make -s clean
	@make -s runbuild

build:
	@echo "Compiling Back.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCBACK) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(BACKDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up Back.."
	@if exist bin del /Q bin\ && rmdir bin