DOTNET := dotnet
CSC := dotnet csc

SRCDRIVER := Driver.cs

BACKDLL := bin/Back2.dll
OUTPUT := -out:$(BACKDLL)

all:
	@make -s clean
	@make -s runbuild

build:
	@echo "Compiling Back2.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(BACKDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up Back2.."
	@if exist bin del /Q bin\ && rmdir bin