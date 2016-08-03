lexer grammar LolcodeScanner;

// Keywords
HAI : 'HAI';
KTHXBYE : 'KTHXBYE';
VISIBLE : 'VISIBLE';
CAN_HAS : 'CAN HAS';
I_HAS_A : 'I HAS A';
OF : 'OF';
AN : 'AN';
WIN : 'WIN';
FAIL : 'FAIL';

// Operators
R : 'R'; // Assignment
// Arithmetic Operators
SUM : 'SUM';
DIFF : 'DIFF';
PRODUKT : 'PRODUKT'; // Multiplication
QUOSHUNT : 'QUOSHUNT'; // Division
// Boolean operators
EITHER : 'EITHER';  // Or
BOTH : 'BOTH'; // And
WON : 'WON'; // Xor
NOT : 'NOT'; // Not

// Literals
fragment Double_quote : '"';

STRING_LITERAL : Double_quote ~["]* Double_quote;
INTEGER_LITERAL : Decimal_digit+;
DOUBLE_LITERAL : Decimal_digit+ '.' Decimal_digit*;

fragment Decimal_digit 
  : '0'..'9'
  ;

IDENTIFIER : [a-zA-Z] [a-zA-Z0-9]*;

// comments
LINE_COMMENT: 'BTW' ~[\n\r]*;
// BLOCK_COMMENT: 'OBTW' ~['TLDR']* 'TLDR'; 

WS: [ \n\t\r]+ -> channel(HIDDEN);