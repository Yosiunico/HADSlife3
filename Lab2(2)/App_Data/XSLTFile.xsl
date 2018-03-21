<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="tareas">
    <html>
      <H3> Lista de tareas de la asignatura selecionada</H3>
      <body>
        <table border="2">
          <tr>
            <td>CODIGO</td>
            <td>DESCRIPCION</td>
            <td>HORAS EST.</td>
          </tr>
          <xsl:for-each select="./tarea">
            <tr>
              <td>
                <xsl:value-of select="./@codigo"/>
              </td>
              <td>
                <xsl:value-of select="./descripcion"/>
              </td>
              <td>
                <xsl:value-of select="./hestimadas"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet> 

