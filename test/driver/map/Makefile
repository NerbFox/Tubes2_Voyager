DOTNET := dotnet
CSC := dotnet csc

SRCINPUTHANDLER := ../../../src/class/inputHandler.cs
SRCMAP := ../../../src/class/map.cs
SRCDRIVER := driver.cs

INPUTMAPDLL := bin/map.dll
OUTPUT := -out:$(INPUTMAPDLL)

build:
	@echo "Compiling map.."
	@$(CSC) $(SRCINPUTHANDLER) $(SRCMAP) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(INPUTMAPDLL)

clean:
	@echo "Cleaning up.."
	@del /Q bin\