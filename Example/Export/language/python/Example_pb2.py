# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: Example.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='Example.proto',
  package='cjProtoBuf',
  syntax='proto3',
  serialized_options=_b('\n\017com.cj.protobufB\021Example_classname\252\002\ncjProtobuf'),
  serialized_pb=_b('\n\rExample.proto\x12\ncjProtoBuf\"\x8c\x02\n\x07\x45xample\x12\n\n\x02id\x18\x01 \x01(\x05\x12\r\n\x05name1\x18\x02 \x01(\x01\x12\r\n\x05name2\x18\x03 \x01(\x02\x12\r\n\x05name3\x18\x04 \x01(\x05\x12\r\n\x05name4\x18\x05 \x01(\x03\x12\r\n\x05name5\x18\x06 \x01(\r\x12\r\n\x05name6\x18\x07 \x01(\x04\x12\r\n\x05name7\x18\x08 \x01(\x08\x12\r\n\x05name8\x18\t \x01(\t\x12\r\n\x05name9\x18\n \x03(\x01\x12\x0e\n\x06name10\x18\x0b \x03(\x02\x12\x0e\n\x06name11\x18\x0c \x03(\x05\x12\x0e\n\x06name12\x18\r \x03(\x03\x12\x0e\n\x06name13\x18\x0e \x03(\r\x12\x0e\n\x06name14\x18\x0f \x03(\x04\x12\x0e\n\x06name15\x18\x10 \x03(\x08\x12\x0e\n\x06name16\x18\x11 \x03(\t\"\x84\x01\n\rExcel_Example\x12\x31\n\x04\x44\x61ta\x18\x01 \x03(\x0b\x32#.cjProtoBuf.Excel_Example.DataEntry\x1a@\n\tDataEntry\x12\x0b\n\x03key\x18\x01 \x01(\x05\x12\"\n\x05value\x18\x02 \x01(\x0b\x32\x13.cjProtoBuf.Example:\x02\x38\x01\x42\x31\n\x0f\x63om.cj.protobufB\x11\x45xample_classname\xaa\x02\ncjProtobufb\x06proto3')
)




_EXAMPLE = _descriptor.Descriptor(
  name='Example',
  full_name='cjProtoBuf.Example',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='id', full_name='cjProtoBuf.Example.id', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name1', full_name='cjProtoBuf.Example.name1', index=1,
      number=2, type=1, cpp_type=5, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name2', full_name='cjProtoBuf.Example.name2', index=2,
      number=3, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name3', full_name='cjProtoBuf.Example.name3', index=3,
      number=4, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name4', full_name='cjProtoBuf.Example.name4', index=4,
      number=5, type=3, cpp_type=2, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name5', full_name='cjProtoBuf.Example.name5', index=5,
      number=6, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name6', full_name='cjProtoBuf.Example.name6', index=6,
      number=7, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name7', full_name='cjProtoBuf.Example.name7', index=7,
      number=8, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name8', full_name='cjProtoBuf.Example.name8', index=8,
      number=9, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name9', full_name='cjProtoBuf.Example.name9', index=9,
      number=10, type=1, cpp_type=5, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name10', full_name='cjProtoBuf.Example.name10', index=10,
      number=11, type=2, cpp_type=6, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name11', full_name='cjProtoBuf.Example.name11', index=11,
      number=12, type=5, cpp_type=1, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name12', full_name='cjProtoBuf.Example.name12', index=12,
      number=13, type=3, cpp_type=2, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name13', full_name='cjProtoBuf.Example.name13', index=13,
      number=14, type=13, cpp_type=3, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name14', full_name='cjProtoBuf.Example.name14', index=14,
      number=15, type=4, cpp_type=4, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name15', full_name='cjProtoBuf.Example.name15', index=15,
      number=16, type=8, cpp_type=7, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name16', full_name='cjProtoBuf.Example.name16', index=16,
      number=17, type=9, cpp_type=9, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=30,
  serialized_end=298,
)


_EXCEL_EXAMPLE_DATAENTRY = _descriptor.Descriptor(
  name='DataEntry',
  full_name='cjProtoBuf.Excel_Example.DataEntry',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='key', full_name='cjProtoBuf.Excel_Example.DataEntry.key', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='value', full_name='cjProtoBuf.Excel_Example.DataEntry.value', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=_b('8\001'),
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=369,
  serialized_end=433,
)

_EXCEL_EXAMPLE = _descriptor.Descriptor(
  name='Excel_Example',
  full_name='cjProtoBuf.Excel_Example',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='Data', full_name='cjProtoBuf.Excel_Example.Data', index=0,
      number=1, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[_EXCEL_EXAMPLE_DATAENTRY, ],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=301,
  serialized_end=433,
)

_EXCEL_EXAMPLE_DATAENTRY.fields_by_name['value'].message_type = _EXAMPLE
_EXCEL_EXAMPLE_DATAENTRY.containing_type = _EXCEL_EXAMPLE
_EXCEL_EXAMPLE.fields_by_name['Data'].message_type = _EXCEL_EXAMPLE_DATAENTRY
DESCRIPTOR.message_types_by_name['Example'] = _EXAMPLE
DESCRIPTOR.message_types_by_name['Excel_Example'] = _EXCEL_EXAMPLE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

Example = _reflection.GeneratedProtocolMessageType('Example', (_message.Message,), {
  'DESCRIPTOR' : _EXAMPLE,
  '__module__' : 'Example_pb2'
  # @@protoc_insertion_point(class_scope:cjProtoBuf.Example)
  })
_sym_db.RegisterMessage(Example)

Excel_Example = _reflection.GeneratedProtocolMessageType('Excel_Example', (_message.Message,), {

  'DataEntry' : _reflection.GeneratedProtocolMessageType('DataEntry', (_message.Message,), {
    'DESCRIPTOR' : _EXCEL_EXAMPLE_DATAENTRY,
    '__module__' : 'Example_pb2'
    # @@protoc_insertion_point(class_scope:cjProtoBuf.Excel_Example.DataEntry)
    })
  ,
  'DESCRIPTOR' : _EXCEL_EXAMPLE,
  '__module__' : 'Example_pb2'
  # @@protoc_insertion_point(class_scope:cjProtoBuf.Excel_Example)
  })
_sym_db.RegisterMessage(Excel_Example)
_sym_db.RegisterMessage(Excel_Example.DataEntry)


DESCRIPTOR._options = None
_EXCEL_EXAMPLE_DATAENTRY._options = None
# @@protoc_insertion_point(module_scope)
