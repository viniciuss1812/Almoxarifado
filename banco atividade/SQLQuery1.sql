-- Atividade 
--1 Select todas as notas fiscais
select ID_NOTA, ID_FOR, ID_SEC, NUM_NOTA, VALOR_NOTA, QTD_ITEM, ICMS, 
ISS, ANO, MES, DATA_NOTA, ID_TIPO_NOTA, OBSERVACAO_NOTA,
EMPENHO_NUM FROM NOTA_FISCAL;

---2 Select todos os itens de entrada de uma nota fiscal
Select * from ITENS_NOTA;
---3 Select todas as requisições
select ID_REQ, ID_CLI, TOTAL_REQ, QTD_ITEN, DATA_REQ,
ANO, MES, ID_SEC, ID_SET, OBSERVACAO from REQUISICAO;
---4 Select todos os itens de saída (req)
SELECT * FROM ITENS_REQ
---5 Select todos os itens de uma nota fiscal 
Select * from ITENS_NOTA where ID_NOTA = 2271;
Select * from ITENS_NOTA where ID_NOTA in (2274,2987);
---6 Select todos os itens de uma requisição
Select * from ITENS_REQ where ID_REQ in (2534, 2597);
---7 Select todas as notas fiscais do mes de competência Janeiro
Select * from NOTA_FISCAL WHERE MES = 1 AND ANO = 2011
---8 Select todos os fornecedores 
SELECT * FROM FORNECEDOR
--9 Select todas as notas de um fornecedor
SELECT * FROM NOTA_FISCAL WHERE ID_FOR=274
--10 Select todas as secretarias
Select ID_SEC, NOME_SEC, ENDRECO_SEC,
BAIRRO_SEC, EMAIL, TEL FROM SECRETARIA;
--11 Select todos os fornecedores que contém a palavra "can" em fantasia
Select * from FORNECEDOR Where FANTASIA Like '%can%';
--12 Retornar todos os itens que o total do item for maior que 100 e menor que 500
SELECT *
FROM ITENS_NOTA
WHERE TOTAL_ITEM > 100 AND TOTAL_ITEM < 500;
SELECT *
FROM ITENS_REQ
WHERE TOTAL_ITEM > 100 AND TOTAL_ITEM < 500;
SELECT *
FROM ITENS_REQ
WHERE TOTAL_REAL> 100 AND TOTAL_REAL < 500;
---13 Retornar todos os produtos que o estoque for maior que 20
SELECT *
FROM ESTOQUE
WHERE QTD_PRO> 20;

--14 retornar o valor total comprado agrupado por fornecedor
SELECT TOP 10 F.ID_FOR, F.FANTASIA, COUNT(N.ID_NOTA) AS QTD, 
AVG(VALOR_NOTA) AS MEDIA, SUM(N.VALOR_NOTA) AS TOTAL FROM FORNECEDOR F
JOIN NOTA_FISCAL N ON F.ID_FOR=N.ID_FOR
GROUP BY F.ID_FOR, F.FANTASIA
ORDER BY TOTAL DESC
SELECT F.UF, COUNT(N.ID_NOTA) AS QTD, 
AVG(VALOR_NOTA) AS MEDIA, SUM(N.VALOR_NOTA) AS TOTAL FROM FORNECEDOR F
JOIN NOTA_FISCAL N ON F.ID_FOR=N.ID_FOR
WHERE F.UF IS NOT NULL
GROUP BY F.UF
ORDER BY F.UF ASC

---16 Retornar a quantidade de produtos em estoque por secretaria
Select E.QTD_PRO as QtdProduto, S.NOME_SEC AS SECRETARIA from ESTOQUE E
left join SECRETARIA S on E.ID_SEC = S.ID_SEC Group By E.QTD_PRO,S.NOME_SEC

--17
Select distinct top 10 P.ID_PRO as ID, INO.TOTAL_ITEM as Entrada, sum(INO.PRE_UNIT) as Valor
from ITENS_NOTA INO join PRODUTO P on INO.ID_PRO= P.ID_PRO Group By P.ID_PRO, INO.TOTAL_ITEM, INO.PRE_UNIT
Order By ino.TOTAL_ITEM desc

--18
Select top 10 E.ID_PRO, sum(IR.TOTAL_ITEM) as Saida, count(E.ID_PRO) as Quantidade
from ESTOQUE E join ITENS_REQ IR on E.ID_PRO= IR.ID_PRO Group By E.ID_PRO, IR.TOTAL_ITEM
Order By count(IR.TOTAL_ITEM) desc

--19
Select sum(N.VALOR_NOTA) as Total, N.MES, N.ANO from NOTA_FISCAL N
Group By N.MES, N.ANO
Order By N.MES asc

--20
Select INO.ID_PRO sum(IR.TOTAL_REAL) as TotalSaida, SUM(INO.TOTAL_ITEM) AS TOTALENTRADA
FROM ITENS_REQ IR JOIN ITENS_NOTA INO ON INO.ID_PRO= IR.ID_PRO
GROUP BY INO.ID_PRO
