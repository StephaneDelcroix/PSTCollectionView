XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=PSTCollectionView
PROJECT=$(PROJECT_ROOT)/PSTCollectionView.xcodeproj
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
SMCS=/Developer/MonoTouch/usr/bin/smcs
TARGET=PSTCollectionView
CONFIGURATION=Release

all: lib$(TARGET).a

debug: CONFIGURATION = Debug
debug: all

lib$(TARGET)-i386.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -miphoneos-version-min=5.0 -configuration $(CONFIGURATION) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphonesimulator/lib$(TARGET).a $@

lib$(TARGET)-armv7.a: $(PROJECT)
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -miphoneos-version-min=5.0 -arch armv7 -configuration $(CONFIGURATION) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/lib$(TARGET).a $@

#lib$(TARGET)-armv7s.a: $(PROJECT)
#	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration $(CONFIGURATION) clean build
#	-mv $(PROJECT_ROOT)/build/$(CONFIGURATION)-iphoneos/lib$(TARGET).a $@

lib$(TARGET).a: lib$(TARGET)-i386.a lib$(TARGET)-armv7.a #lib$(TARGET)-armv7s.a
	lipo -create -output $@ $^

#PSTCollectionView.dll: ApiDefinition.cs StructsAndEnums.cs Extra.cs AssemblyInfo.cs libarclite.a libarclite.linkwith.cs lib$(TARGET).a
#	mkdir -p ios
#	$(BTOUCH) -unsafe ApiDefinition.cs -s StructsAndEnums.cs --tmpdir=ios --sourceonly ios/sources.list
#	$(SMCS) -noconfig -o- -out:$@ -res:libarclite.a libarclite.linkwith.cs lib$(TARGET).a AssemblyInfo.cs StructsAndEnums.cs Extra.cs @ios/sources.list -target:library -unsafe -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll -reference:/Developer/MonoTouch/usr/lib/mono/2.1/System.Core.dll  

#libarclite.a: clean-all
#	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.a > libarclite.a
#	curl -L https://github.com/dalexsoto/MonoTouch-PSPDFKit-bindings/raw/master/AlexTouch.PSPDFKit/libarclite.linkwith.cs > libarclite.linkwith.cs

clean: 
	-rm -f *.a *.dll

clean-all: clean
	-rm -rf ios libarclite.linkwith.cs

.PHONY: clean clean-all
