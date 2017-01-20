mkdir dali-csharp-binder
cd dali-csharp-binder
mkdir csharp-src
mkdir src
cd csharp-src
mkdir internal
mkdir public

cd ../../

cat csharp-binder-src | xargs cp -t dali-csharp-binder/src/
cat csharp-binder-internal | xargs cp -t dali-csharp-binder/csharp-src/internal/
cat csharp-binder-public | xargs cp -t dali-csharp-binder/csharp-src/public/
