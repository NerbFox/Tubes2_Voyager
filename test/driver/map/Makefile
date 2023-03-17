DOTNET := dotnet
CSC := dotnet csc

SRCINPUTHANDLER := ../../../src/class/inputHandler.cs
SRCMAP := ../../../src/class/map.cs
SRCDRIVER := driver.cs

INPUTMAPDLL := bin/map.dll
OUTPUT := -out:$(INPUTMAPDLL)

build:
	@echo "Compiling map.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCINPUTHANDLER) $(SRCMAP) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(INPUTMAPDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up map.."
	@if exist bin del /Q bin\ && rmdir bin