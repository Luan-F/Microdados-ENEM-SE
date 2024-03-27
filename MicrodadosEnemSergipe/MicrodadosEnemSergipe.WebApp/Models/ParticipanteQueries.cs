using MicrodadosEnemSergipe.WebApp.Data;
public class ParticipanteQueries : AbstractQueryClass {
	public ParticipanteQueries(ContextConnection context)
	{
		provasAreaConhecimento = context.provaareaconhecimento.AsQueryable();
		participantes = context.participante.AsQueryable();
		redacoes = context.redacao.AsQueryable();
		escolaridades = context.escolaridade.AsQueryable();
		participanteDados = ExecuteJoin();
	}

	public IQueryable<ParticipanteDados> ExecuteJoin()
	{
		var join = participantes.Join(provasAreaConhecimento,
				participante => participante.NumeroInscricao,
				provaAC => provaAC.NumeroInscricao,
				(participante, provaAC) =>
					new {
						NInscricao = participante.NumeroInscricao,
						provaAC.NotaCH,
						provaAC.NotaCN,
						provaAC.NotaLC,
						provaAC.NotaMT,
						PresencaDia1 = provaAC.PresencaCH,
						PresencaDia2 = provaAC.PresencaCN,
		}).Join(redacoes,
				notaParticipante => notaParticipante.NInscricao,
				redacao => redacao.NumeroInscricao,
				(notaParticipante, redacao) =>
					new {
						NInscricao = notaParticipante.NInscricao,
						notaParticipante.NotaCH,
						notaParticipante.NotaCN,
						notaParticipante.NotaLC,
						notaParticipante.NotaMT,
						redacao.NotaComp1,
						redacao.NotaComp2,
						redacao.NotaComp3,
						redacao.NotaComp4,
						redacao.NotaComp5,
						redacao.NotaRedacao,
						notaParticipante.PresencaDia1,
						notaParticipante.PresencaDia2,
		}).Join(escolaridades,
				notaParticipante => notaParticipante.NInscricao,
				escolaridade => escolaridade.NumeroInscricao,
				(notaParticipante, escolaridade) =>
					new {
						NumeroInscricao = notaParticipante.NInscricao,
						notaParticipante.NotaCH,
						notaParticipante.NotaCN,
						notaParticipante.NotaLC,
						notaParticipante.NotaMT,
						notaParticipante.NotaComp1,
						notaParticipante.NotaComp2,
						notaParticipante.NotaComp3,
						notaParticipante.NotaComp4,
						notaParticipante.NotaComp5,
						notaParticipante.NotaRedacao,
						escolaridade.NomeMunicipio,
						notaParticipante.PresencaDia1,
						notaParticipante.PresencaDia2,
		});

		return join.Select(j => new ParticipanteDados {
				NumeroInscricao = j.NumeroInscricao,
				NomeMunicipio = j.NomeMunicipio,
				NotaCH = j.NotaCH,
				NotaCN = j.NotaCN,
				NotaLC = j.NotaLC,
				NotaMT = j.NotaMT,
				NotaComp1 = j.NotaComp1,
				NotaComp2 = j.NotaComp2,
				NotaComp3 = j.NotaComp3,
				NotaComp4 = j.NotaComp4,
				NotaComp5 = j.NotaComp5,
				NotaRedacao = j.NotaRedacao,
				NotaGeral = (j.NotaCH + j.NotaLC + j.NotaRedacao
						+ j.NotaCN + j.NotaMT) / 5,
				PresencaDia1 = j.PresencaDia1,
				PresencaDia2 = j.PresencaDia2,
		});
	}
}
