#include <stdio.h>

struct Obj
{
  int in_size;
  int out_size;
  int a;
  double b;
};

__declspec(dllexport) void Test(struct Obj* obj, double* in_array, double* out_array)
{
  printf("a: %i\n", obj->a);  
  printf("b: %f\n", obj->b);

  for(int in_index = 0; in_index < obj->in_size; ++in_index)
    printf("in_array[%i]: %f\n", in_index, in_array[in_index]);

  for(int out_index = 0; out_index < obj->out_size; ++out_index)
    out_array[out_index] = obj->b * out_index;
}
